    public static string readControlText(Control varControl) {
      if (varControl.InvokeRequired) {
        return (string)varControl.Invoke(
          new Func<String>(() => readControlText(varControl))
        );
      }
      else {
        string varText = varControl.Text;
        return varText;
      }
    }
