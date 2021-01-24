    public class MyTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        public bool OnTouch(View v, MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                // do your stuff here
                return true;
            }
            if (e.Action == MotionEventActions.Up)
            {
                // do your stuff here
                return true;
            }
            return false;
        }
    }
