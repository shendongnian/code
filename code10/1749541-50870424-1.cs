            /// <summary>
            /// Method that invokes action parameter x times in multiple threads (parallel) and returns the elapsed time
            /// </summary>
            /// <param name="action"></param>
            /// <param name="antalKald"></param>
            /// <returns></returns>
            public string ExecuteAndTimeAction(Action action, string antalKald)
            {
                // Here is set the bound variable, and if I debug I can see it getting set to Working...
                IsDoingWork = "Working...";
                DoEvent();//flushes the UI msg queue
                var sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < Convert.ToInt32(antalKald); i++)
                {
                   action.Invoke();
                }
                sw.Stop();
                // Here I am resetting the variable and again in debug I can see it change, but nothing happens in the view
                IsDoingWork = "";
                DoEvent();//flushes the UI msg queue
                return $"Elapsed time: {sw.Elapsed}";
            }
             The second approach is a hack and it will still freeze the UI but will get the job done for you. I suggest you go for the first approach, It is way better but takes effort to implement.
