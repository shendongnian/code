    public class Model
    {
        private TimeSpan[] _timeSpans = new TimeSpan[4] { new TimeSpan(), new TimeSpan(), new TimeSpan(), new TimeSpan() };
        public TimeSpan Time1
        {
            get { return _timeSpans[0]; }
            set { _timeSpans[0] = value; }
        }
        public TimeSpan Time2
        {
            get { return _timeSpans[1]; }
            set { _timeSpans[1] = value; }
        }
        public TimeSpan Time3
        {
            get { return _timeSpans[2]; }
            set { _timeSpans[2] = value; }
        }
        public TimeSpan Time4
        {
            get { return _timeSpans[3]; }
            set { _timeSpans[3] = value; }
        }
        // DateTime.TimeOfDay holds the time portion of a time
        public TimeSpan GetDifference(TimeSpan currentTime)
        {
            int start = -1;
            for(int i = 0; i<_timeSpans.Length;i++)
            {
                if(_timeSpans[i] >= currentTime)
                {
                    start = i;
                    break;
                }
            }
            if(start == -1) throw new ArgumentException("handle the case where currentTime is smaller than all of them");
            int end = (start + 1 < _timeSpans.Length) ? start + 1 : 0;
            return _timeSpans[end] - _timeSpans[start];
        }
