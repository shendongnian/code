    public class MakeReadableTimeType
    {
        public class GetMakeReadableTimeType
        {
            public bool
                DisplayDays
                , DisplayHours
                , DisplayMinutes
                , DisplaySeconds
                , DisplayMilliseconds;
            public long SourceMilliseconds;
        }
        public static string MakeReadableTime(GetMakeReadableTimeType GetMakeReadableTime)
        {
            GetMakeReadableTimeType FunctionGet = GetMakeReadableTime;
            string
                FunctionResult
                , CurrentTimeText = "";
            TimeSpan TimeSpanObject = TimeSpan.FromMilliseconds(FunctionGet.SourceMilliseconds);
            long
                CurrentDays = 0
                , CurrentHours = 0
                , CurrentMinutes = 0
                , CurrentSeconds = 0
                , CurrentMilliseconds = 0;
            List<string> TimeTextList = new List<string>();
            if (TimeSpanObject.Days > 0)
                if (FunctionGet.DisplayDays == true)
                    CurrentDays += TimeSpanObject.Days;
                else
                {
                    if (FunctionGet.DisplayHours == true)
                        CurrentHours += (long)TimeSpanObject.Days * 24;
                    else
                    {
                        if (FunctionGet.DisplayMinutes == true)
                            CurrentMinutes += (long)TimeSpanObject.Days * 24 * 60;
                        else
                        {
                            if (FunctionGet.DisplaySeconds == true)
                                CurrentSeconds += (long)TimeSpanObject.Days * 24 * 60 * 60;
                            else
                            {
                                if (FunctionGet.DisplayMilliseconds == true)
                                    CurrentMilliseconds += (long)TimeSpanObject.Days * 24 * 60 * 60 * 1000;
                            }
                        }
                    }
                }
            if (TimeSpanObject.Hours > 0)
                if (FunctionGet.DisplayHours == true)
                    CurrentHours += TimeSpanObject.Hours;
                else
                {
                    if (FunctionGet.DisplayMinutes == true)
                        CurrentMinutes += (long)TimeSpanObject.Hours * 60;
                    else
                    {
                        if (FunctionGet.DisplaySeconds == true)
                            CurrentSeconds += (long)TimeSpanObject.Hours * 60 * 60;
                        else
                        {
                            if (FunctionGet.DisplayMilliseconds == true)
                                CurrentMilliseconds += (long)TimeSpanObject.Hours * 60 * 60 * 1000;
                        }
                    }
                }
            if (TimeSpanObject.Minutes > 0)
                if (FunctionGet.DisplayMinutes == true)
                    CurrentMinutes += TimeSpanObject.Minutes;
                else
                {
                    if (FunctionGet.DisplaySeconds == true)
                        CurrentSeconds += (long)TimeSpanObject.Minutes * 60;
                    else
                    {
                        if (FunctionGet.DisplayMilliseconds == true)
                            CurrentMilliseconds += (long)TimeSpanObject.Minutes * 60 * 1000;
                    }
                }
            if (TimeSpanObject.Seconds > 0)
                if (FunctionGet.DisplaySeconds == true)
                    CurrentSeconds += TimeSpanObject.Seconds;
                else
                {
                    if (FunctionGet.DisplayMilliseconds == true)
                        CurrentMilliseconds += (long)TimeSpanObject.Seconds * 1000;
                }
            if (TimeSpanObject.Milliseconds > 0)
                if (FunctionGet.DisplayMilliseconds == true)
                    CurrentMilliseconds += TimeSpanObject.Milliseconds;
            if (CurrentDays > 0)
            {
                CurrentTimeText = CurrentDays.ToString();
                if (CurrentDays == 1)
                    CurrentTimeText += " Day";
                else
                    CurrentTimeText += " Days";
                TimeTextList.Add(CurrentTimeText);
            }
            if (CurrentHours > 0)
            {
                CurrentTimeText = CurrentHours.ToString();
                if (CurrentHours == 1)
                    CurrentTimeText += " Hour";
                else
                    CurrentTimeText += " Hours";
                TimeTextList.Add(CurrentTimeText);
            }
            if (CurrentMinutes > 0)
            {
                CurrentTimeText = CurrentMinutes.ToString();
                if (CurrentMinutes == 1)
                    CurrentTimeText += " Minute";
                else
                    CurrentTimeText += " Minutes";
                TimeTextList.Add(CurrentTimeText);
            }
            if (CurrentSeconds > 0)
            {
                CurrentTimeText = CurrentSeconds.ToString();
                if (CurrentSeconds == 1)
                    CurrentTimeText += " Second";
                else
                    CurrentTimeText += " Seconds";
                TimeTextList.Add(CurrentTimeText);
            }
            if (CurrentMilliseconds > 0)
            {
                CurrentTimeText = CurrentMilliseconds.ToString();
                if (CurrentMilliseconds == 1)
                    CurrentTimeText += " Millisecond";
                else
                    CurrentTimeText += " Milliseconds";
                TimeTextList.Add(CurrentTimeText);
            }
            if (TimeTextList.Count > 0)
            {
                TimeTextList.Remove(TimeTextList.Last());
                if (TimeTextList.Count > 0)
                    if (TimeTextList.Count > 1)
                        FunctionResult = string.Join(", ", TimeTextList) + " and " + CurrentTimeText;
                    else
                        FunctionResult = TimeTextList.First() + " and " + CurrentTimeText;
                else
                    FunctionResult = CurrentTimeText;
            }
            else
                FunctionResult = "0 Milliseconds";
            return FunctionResult;
        }
    }
