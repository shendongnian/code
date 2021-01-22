                int sleepTime = 5 * 60;    // 5 minutes
                for (int secondsRemaining = sleepTime; secondsRemaining > 0; secondsRemaining --)
                {
                    double minutesPrecise = secondsRemaining / 60;
                    double minutesRounded = Math.Round(minutesPrecise, 0);
                    int seconds = Convert.ToInt32((minutesRounded * 60) - secondsRemaining);
                    Console.Write($"\rProcess will resume in {minutesRounded}:{String.Format("{0:D2}", -seconds)} ");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("");
