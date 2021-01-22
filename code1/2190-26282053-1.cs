        public static string ToStringWithOrdinal(this DateTime d)
        {
            var result = "";
            bool bReturn = false;            
            
            switch (d.Day % 100)
            {
                case 11:
                case 12:
                case 13:
                    result = d.ToString("dd'th' MMMM yyyy");
                    bReturn = true;
                    break;
            }
            if (!bReturn)
            {
                switch (d.Day % 10)
                {
                    case 1:
                        result = d.ToString("dd'st' MMMM yyyy");
                        break;
                    case 2:
                        result = d.ToString("dd'nd' MMMM yyyy");
                        break;
                    case 3:
                        result = d.ToString("dd'rd' MMMM yyyy");
                        break;
                    default:
                        result = d.ToString("dd'th' MMMM yyyy");
                        break;
                }
            }
            if (result.StartsWith("0")) result = result.Substring(1);
            return result;
        }
    }
