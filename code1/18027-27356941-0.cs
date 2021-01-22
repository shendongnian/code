    public static class Extensions
    {
        public static void Raise(this EventHandler e, object sender, EventArgs args = null)
        {
            var e1 = e;
            if (e1 != null)
            {
                if (args == null)
                    args = new EventArgs();
                e1(sender, args);
            }                
        }
      }
