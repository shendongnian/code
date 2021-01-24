        public class UpdateDataProgress
        {
            public void ExecuteFucntion(System.Windows.Forms.ProgressBar progbar)
            {
                for (int i = 0; i < 100; i++)
                {
                    progbar.Value = i;
                }
            }
        }
