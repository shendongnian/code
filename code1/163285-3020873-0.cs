    taxid = GetNullableInt32(ddlProductTax.SelectedValue);
    public static int? GetNullableInt32(string str)
    {
            int result;
            if (Int32.TryParse(str, out result))
            {
                return result;
            }
            return null;
    }
