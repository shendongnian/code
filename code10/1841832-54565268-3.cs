private void Graph_QuantumStarted(AudioGraph sender, object args)
        {
            ...
            double decibels = dataInFloats.Aggregate<float, double>(0f, (current, sample) => current + Math.Abs(sample)); // I dislike the fact that the decibels variable is initially inaccurate, but it's your codebase.
            decibels = 20 * Math.Log10(decibels / dataInFloats.Length);
            if (scanning) // class variable (bool), you can set it from the UI thread like this
            {
                _decibelList.Add(decibels); // I assume you made this a class variable
            }
            else if (decibels == Double.NaN)
            {
                // Code by case below
            }
            else if (decibels > _sensitivity) //_sensitivity is a class variable(double), initialized to Double.NaN
            {
                LoudNoise?.Invoke(this, true); // Calling events is a wee bit expensive, you probably want to handle the sensitivity before Invoking it, I'm also going to do it like that to make this demo simpler
            }
        }
 1. If you can control make sure there's no spike loud enough you want it to go off you can just take the max value of all those frames and say if it's over the sensitivity  is ``maxDecibels + Math.Abs(maxDecibels* 0.2)`` (the decibels could be negative, hence Abs).
double maxDecibels = _decibelList.OrderByDescending(x => x)[0];
_sensitivity = maxDecibels + Math.Abs(maxDecibels* 0.2);
 2. If you can't control when there's a spike, then you could collect those frames, sort, and have it take item [24] (of your 100 item list) and say that's the sensitivity.
sensitivity = _decibelList.OrderByDescending(x => x)[24]; // If you do a variable time you can just take Count/4 - 1 as the index
 3. (I think it's the best but I really don't know statistics) Walk the list of frame's decibels and track the average difference in value and the what index changed it most. Afterwards, find the max value from after that index and say 75% of the change to there is the sensitivty. (Don't use a LinkedList on this)
int greatestChange, changeIndex = 0;
double p = Double.NaN; // Previous
for (int i = 0; i < _decibelList.Count(); i++)
{
    if (p != Double.Nan)
    {
        change = Math.Abs(_decibelList[i] - p);
        if (Math.Abs(change > greatestChange)
        {
            greatestChange = change;
            changeIndex = i;
        } 
    }
    p = _decibelList[i];
}
int i = changeIndex;
p = Double.NaN; // reused
double c= Double.NaN; // Current
do
{
    p = c != Double.NaN ? c : _decibelList[i];
    c = _decibelList[++i];
} while (c < p);
_sensitivity = ((3 * c) + _decibelList[changeIndex]) / 4;
#Note: You can (kind of) remove the need to sort by having a LinkedList and inserting in the appropiate place
