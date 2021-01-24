    public class MediaButtonReceiver : MediaSession.Callback
    {
        static long lastClick = 0;
        Context ctx;
        public MediaButtonReceiver(Context ctx)
        {
            this.ctx = ctx;
        }
        public override bool OnMediaButtonEvent(Intent mediaButtonIntent)
        {
            if (mediaButtonIntent.Action != Intent.ActionMediaButton)
                return false;
            var keyEvent = (KeyEvent)mediaButtonIntent.GetParcelableExtra(Intent.ExtraKeyEvent);
            switch (keyEvent.KeyCode)
            {
                case Keycode.Headsethook:
                    if (canClick())
                        Activity_Player.Instance.PlayOrPauseLogic();
                    break;
                case Keycode.MediaPlay:
                    if (canClick())
                        Activity_Player.Instance.PlayOrPauseLogic();
                    break;
                case Keycode.MediaPlayPause:
                    if (canClick())
                        Activity_Player.Instance.PlayOrPauseLogic();
                    break;
                case Keycode.MediaNext:
                    if (Activity_Player.CurrentSongObject != null && canClick())
                        Activity_Player.Instance.ChooseRandomNewSongAndPlay(false);
                    break;
                case Keycode.MediaPrevious:
                    if (Activity_Player.CurrentSongObject != null && canClick())
                        Activity_Player.mediaPlayer.SeekTo(0);
                    break;
            }
            return base.OnMediaButtonEvent(mediaButtonIntent);
        }
        private bool canClick()
        {
            if (lastClick < Java.Lang.JavaSystem.CurrentTimeMillis() - 500) // needs to be atleast one second bigger 
            {
                lastClick = Java.Lang.JavaSystem.CurrentTimeMillis();
                return true;
            }
            else
                return false;
        }
    }
