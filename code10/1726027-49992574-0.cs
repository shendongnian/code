            var task = new TaskCompletionSource<string>();
           
            var _workingDirectory = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var sourceMp4 = path;
            var destinationPath1 = IntentHelper.CreateNewVideoPath();
            FFMpeg ffmpeg = new FFMpeg(Android.App.Application.Context, _workingDirectory);
            TransposeVideoFilter vfTranspose = new TransposeVideoFilter(TransposeVideoFilter.NINETY_CLOCKWISE);
            var filters = new List<VideoFilter>();
            filters.Add(vfTranspose);
            Task.Run(() =>
            {
                var sourceClip = new Clip(System.IO.Path.Combine(_workingDirectory, sourceMp4)) { videoFilter = VideoFilter.Build(filters) };
                var onComplete = new MyCommand((_) =>
                {
                    CurrentActivity.RunOnUiThread(() =>
                    {
                        task.SetResult(destinationPath1);
                        //progress.Dismiss();
                    });
                });
                var onMessage = new MyCommand((message) =>
                {
                    System.Console.WriteLine(message);
                });
                var callbacks = new FFMpegCallbacks(onComplete, onMessage);
                string[] cmds = new string[] {
                        "-y",
                        "-i",
                        sourceClip.path,
                        "-strict", "experimental",
                        "-vcodec", "libx264",
                        "-preset", "ultrafast",
                        "-crf","38", "-acodec","aac", "-ar", "44100" ,
                        "-q:v", "12",
                          "-vf",sourceClip.videoFilter,
                        destinationPath1 ,
                          };
                ffmpeg.Execute(cmds, callbacks);
                return task.Task;
            });
            return task.Task;
        }
        public class MyCommand : ICommand
        {
            public delegate void ICommandOnExecute(object parameter = null);
            public delegate bool ICommandOnCanExecute(object parameter);
            private ICommandOnExecute _execute;
            private ICommandOnCanExecute _canExecute;
            public MyCommand(ICommandOnExecute onExecuteMethod)
            {
                _execute = onExecuteMethod;
            }
            public MyCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
            {
                _execute = onExecuteMethod;
                _canExecute = onCanExecuteMethod;
            }
            #region ICommand Members
            public event EventHandler CanExecuteChanged
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }
            public bool CanExecute(object parameter)
            {
                if (_canExecute == null && _execute != null)
                    return true;
                return _canExecute.Invoke(parameter);
            }
            public void Execute(object parameter)
            {
                if (_execute == null)
                    return;
                _execute.Invoke(parameter);
            }
            #endregion
        }
