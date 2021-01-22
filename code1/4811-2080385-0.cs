    public static void BindControlToEnum(DataBoundControl ControlToBind ,Type type)
        {
            //ListControl
    
            if (type == null)
                throw new ArgumentNullException("type");
            else if (ControlToBind==null )
                throw new ArgumentNullException("ControlToBind");
            if (!type.IsEnum)
                throw new ArgumentException("Only enumeration type is expected.");
    
            Dictionary<int, string> pairs = new Dictionary<int, string>();
    
            foreach (int i in Enum.GetValues(type))
            {
                pairs.Add(i, Enum.GetName(type, i));
            }
            ControlToBind.DataSource = pairs;
            ListControl lstControl = ControlToBind as ListControl;
            if (lstControl != null)
            {
                lstControl.DataTextField = "Value";
                lstControl.DataValueField = "Key";
            }
            ControlToBind.DataBind();
           
        }
