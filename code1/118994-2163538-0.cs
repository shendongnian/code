    public class InputTextWithLabelControl : CompositeControl {
      HtmlGenericControl _label;
      HtmlInputText _text;
      public string Label {
        get {
          EnsureChildControls();
          return _label.InnerText;
        }
        set {
          EnsureChildControls();
          _label.InnerText = value;
        }
      }
      public string Text {
        get {
          EnsureChildControls();
          return _text.Value;
        }
        set {
          EnsureChildControls();
          _text.Value = value;
        }
      }
      protected override void CreateChildControls() {
        Controls.Clear();
        _label = new HtmlGenericControl("span");
        _label.ID = "label";
        _text = new HtmlInputText();
        _text.ID = "text";
        
        Controls.Add(_label);
        Controls.Add(_text);
      }
    }
