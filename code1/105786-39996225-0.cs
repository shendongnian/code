    private bool isNumber(object p_Value)
        {
            try
            {
                if (int.Parse(p_Value.ToString()).GetType().Equals(typeof(int)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
