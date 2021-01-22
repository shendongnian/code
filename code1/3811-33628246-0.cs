    public static class Utils {      
    public static bool TryParse<Tin, Tout>(this Tin obj, Func<Tin, Tout> onConvert, Action<Tout> onFill, Action<Exception> onError) {
      Tout value = default(Tout);
      bool ret = true;
      try {
        value = onConvert(obj);
      }
      catch (Exception exc) {
        onError(exc);
        ret = false;
      }
      if (ret)
        onFill(value);
      return ret;
    }
    public static bool TryParse(this string str, Action<int?> onFill, Action<Exception> onError) {
      return Utils.TryParse(str
        , s => string.IsNullOrEmpty(s) ? null : (int?)int.Parse(s)
        , onFill
        , onError);
    }
    public static bool TryParse(this string str, Action<int> onFill, Action<Exception> onError) {
      return Utils.TryParse(str
        , s => int.Parse(s)
        , onFill
        , onError);
    }
    }
