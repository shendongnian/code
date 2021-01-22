     public static void FillByEnumOrderByNumber<TEnum>(this System.Windows.Forms.ListControl ctrl, TEnum enum1, bool showValueInDisplay = true) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");
            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                         select
                            new
                             KeyValuePair<TEnum, string>(   (enumValue), enumValue.ToString());
            ctrl.DataSource = values
                .OrderBy(x => x.Key)
                
                .ToList();
            ctrl.DisplayMember = "Value";
            ctrl.ValueMember = "Key";
            ctrl.SelectedValue = enum1;
        }
        public static void  FillByEnumOrderByName<TEnum>(this System.Windows.Forms.ListControl ctrl, TEnum enum1, bool showValueInDisplay = true  ) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");
            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                         select 
                            new 
                             KeyValuePair<TEnum,string> ( (enumValue),  enumValue.ToString()  );
            
            ctrl.DataSource = values
                .OrderBy(x=>x.Value)
                .ToList();
            
            ctrl.DisplayMember = "Value";
            ctrl.ValueMember = "Key";
            ctrl.SelectedValue = enum1;
        }
