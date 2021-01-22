    public static class FormExtensions
    {
      public static void InvokeEx<T>(this T @this, Action<T> action) where T : Form
      {
        if (@this.InvokeRequired)
        {
          @this.Invoke(action, @this);
        }
        else
        {
          action(@this);
        }
      }
    }
