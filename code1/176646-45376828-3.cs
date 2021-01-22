            var file = $"{Path.GetTempPath()}temp.mp3";
                if (!File.Exists(file))
                {
                    using (Stream output = new FileStream(file, FileMode.Create))
                    {
                        output.Write(Properties.Resources.Kalimba, 0, Properties.Resources.Kalimba.Length);
                    }
                }
                var wmp = new WindowsMediaPlayer { URL = file };
                wmp.controls.play();
