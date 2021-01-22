      public bool IsFieldValid()
        {
                 Error.SetError(label, "");
            if (_Validate.Length == 0)
            {
             return true;
            }
            else 
            {
                switch (_Validate)
                { 
                    case "General":
                        return ValidateText();
                    case "Int":
                        return ValidateInt();
                    case "Decimal":
                        return ValidateDecimal();
                    case "Length":
                        return ValidateTextLength();
                    default:
                        return true;
                }
            }
            
        }
        public bool ValidateText()
        {
          
                this.shapeContainer1.BackColor = this.BackColor;
                if (_CanBeNull == true & this.textBox.Text.Trim() == "")
                {
               
                    return true;
                }
                else
                {
                    if (this.textBox.Text.Trim().Length > 0)
                    {
                        return true;
                    }
                    else
                    { 
                        Error.SetError(label, CustomError);
                        return false;
                    }
   
            }
        }
        public bool ValidateDecimal()
        {
            if (_CanBeNull == true & this.textBox.Text.Trim() == "")
            {
                return true;
            }
            else
            {
                try
                {
                    this.textBox.Text = this.textBox.Text.Replace("£", "");
                    Decimal Val = System.Convert.ToDecimal(this.textBox.Text);
                    if (_MaxValue == 0)
                    {
                        return true;
                    }
                    if ((Val >= _MinValue) && (Val <= _MaxValue))
                    {
                        return true;
                    }
                    else
                    {
                        this.Error.SetError(this.label, "Value must be between " + _MinValue.ToString() + " and " + _MaxValue);
                        return false;
                    }
                }
                catch
                {
                    this.Error.SetError(this.label, "Error converting value to a decimal value");
                    return false;
                }
            }
        }
        public bool ValidateInt()
        {
            if (_CanBeNull == true & this.textBox.Text.Trim() == "")
            {
                return true;
            }
            else
            {
                try
                {
                    int Val = System.Convert.ToInt32(this.textBox.Text);
                    if (_MaxValue == 0)
                    {
                        return true;
                    }
                    if ((Val >= _MinValue) && (Val <= _MaxValue))
                    {
                        return true;
                    }
                    else
                    {
                        this.Error.SetError(label,"Value must be between " + _MinValue.ToString() + " and " + _MaxValue);
                        return false;
                    }
                }
                catch
                {
                    this.Error.SetError(label,"Error converting value to a numeric value");
                    return false;
                }
            }
        }
        public bool ValidateTextLength()
        {
            if (_CanBeNull == true & this.textBox.Text.Trim() == "")
            {
                return true;
            }
            else
            {
                int Val = this.textBox.Text.Length;
                if ((Val >= _MinValue) && (Val <= _MaxValue))
                {
                    return true;
                }
                else
                {
                    this.Error.SetError(label,"Length of text must be between " + _MinValue.ToString() + " and " + _MaxValue);
                    return false;
                }
            }
        }
        public String TxtReturnXML
        { 
            get {
                string S;
                XmlDocument doc = new XmlDocument();
                XmlNode Xe = doc.CreateNode(XmlNodeType.Element,"Value",null);
                Xe.InnerText = this.textBox.Text.ToString();
                S = Xe.OuterXml;
                doc = null;
                Xe = null;
                return S;
            }
            
        
        }
        public bool LoadedXml(XmlNode X)
        {
            try
            {
                _Validate = X.Attributes["Validate"].Value;
                this.textBox.Text = X.Attributes["DefaultValue"].Value.ToString();
                this.label.Text = X.Attributes["LabelText"].Value.ToString();
                if (System.Convert.ToInt32(X.Attributes["Height"].Value) > 0)
                {
                    this.Height = System.Convert.ToInt32(X.Attributes["Height"].Value) + 10;
                    textBox.Multiline = true;
                    this.textBox.Height = System.Convert.ToInt32(X.Attributes["Height"].Value);
                }
                if (System.Convert.ToInt32(X.Attributes["Width"].Value) > 0)
                {
                    this.textBox.Width = System.Convert.ToInt32(X.Attributes["Width"].Value);
                    this.textBox.Left = (this.Width - 20) - System.Convert.ToInt32(X.Attributes["Width"].Value);
                }
                _CanBeNull = System.Convert.ToBoolean(X.Attributes["CanBeNull"].Value);
                _PassBack = System.Convert.ToBoolean(X.Attributes["PassBack"].Value);
    
                CustomError = X.Attributes["CustomError"].Value.ToString();
                CustomWarning = X.Attributes["CustomWarning"].Value.ToString();
                if (CustomWarning.Length > 0)
                {
                    Error.SetError(label, CustomWarning);
                    
                }
                _MinValue = System.Convert.ToInt32(X.Attributes["MinValue"].Value);
                _MaxValue = System.Convert.ToInt32(X.Attributes["MaxValue"].Value);
            }
            catch {
                return false;
            }
            
                _LoadedXml = X;
                return true;
           
    
    }
