    class edvTools {
    	/// <summary>
    	/// Tente la conversion d'une valeur suivant un type EDVType
    	/// </summary>
    	/// <param name="pValue">Référence de la valeur à convertir</param>
    	/// <param name="pType">Type EDV en sortie</param>
    	/// <returns></returns>
    	public static bool TryParse(ref object pValue, System.Type pType)
    	{
    		int lIParsed;
    		double lDParsed;
    		string lsValue;
    		if (pValue == null) return false;
    		if (pType.Equals(typeof(bool))) {
    			bool lBParsed;
    			if (pValue is bool) return true;
    			if (double.TryParse(pValue.ToString(), out lDParsed)) {
    				pValue = lDParsed != 0D;
    				return true;
    			}
    			if (bool.TryParse(pValue.ToString(), out lBParsed)) {
    				pValue = lBParsed;
    				return true;
    			}
    			else
    				return false;
    		}
    		if (pType.Equals(typeof(Double))) {
    			if (pValue is Double) return true;
    			if (double.TryParse(pValue.ToString(), out lDParsed)
    				|| double.TryParse(pValue.ToString().Replace(NumberDecimalSeparatorNOT, NumberDecimalSeparator), out lDParsed)) {
    				pValue = lDParsed;
    				return true;
    			}
    			else
    				return false;
    		}
    		if (pType.Equals(typeof(int))) {
    			if (pValue is int) return true;
    			if (Int32.TryParse(pValue.ToString(), out lIParsed)) {
    				pValue = lIParsed;
    				return true;
    			}
    			else if (double.TryParse(pValue.ToString(), out lDParsed)) {
    				pValue = (int)lDParsed;
    				return true;
    			}
    			else
    				return false;
    		}
    		if (pType.Equals(typeof(Byte))) {
    			if (pValue is byte) return true;
    			byte lByte;
    			if (Byte.TryParse(pValue.ToString(), out lByte)) {
    				pValue = lByte;
    				return true;
    			}
    			else if (double.TryParse(pValue.ToString(), out lDParsed)) {
    				pValue = (byte)lDParsed;
    				return true;
    			}
    			else
    				return false;
    		}
    		if (pType.Equals(typeof(long))) {
    			long lLParsed;
    			if (pValue is long) return true;
    			if (long.TryParse(pValue.ToString(), out lLParsed)) {
    				pValue = lLParsed;
    				return true;
    			}
    			else if (double.TryParse(pValue.ToString(), out lDParsed)) {
    				pValue = (long)lDParsed;
    				return true;
    			}
    			else
    				return false;
    		}
    		if (pType.Equals(typeof(Single))) {
    			if (pValue is float) return true;
    			Single lSParsed;
    			if (Single.TryParse(pValue.ToString(), out lSParsed)
    				|| Single.TryParse(pValue.ToString().Replace(NumberDecimalSeparatorNOT, NumberDecimalSeparator), out lSParsed)) {
    				pValue = lSParsed;
    				return true;
    			}
    			else
    				return false;
    		}
    		if (pType.Equals(typeof(DateTime))) {
    			if (pValue is DateTime) return true;
    			DateTime lDTParsed;
    			if (DateTime.TryParse(pValue.ToString(), out lDTParsed)) {
    				pValue = lDTParsed;
    				return true;
    			}
    			else if (pValue.ToString().Contains("UTC")) //Date venant de JScript
    			{
    				if (_MonthsUTC == null) InitMonthsUTC();
    				string[] lDateParts = pValue.ToString().Split(' ');
    				lDTParsed = new DateTime(int.Parse(lDateParts[5]), _MonthsUTC[lDateParts[1]], int.Parse(lDateParts[2]));
    				lDateParts = lDateParts[3].ToString().Split(':');
    				pValue = lDTParsed.AddSeconds(int.Parse(lDateParts[0]) * 3600 + int.Parse(lDateParts[1]) * 60 + int.Parse(lDateParts[2]));
    				return true;
    			}
    			else
    				return false;
    
    		}
    		if (pType.Equals(typeof(Array))) {
    			if (pValue is System.Collections.ICollection || pValue is System.Collections.ArrayList)
    				return true;
    			return pValue is System.Data.DataTable
    				|| pValue is string && (pValue as string).StartsWith("<");
    		}
    		if (pType.Equals(typeof(DataTable))) {
    			return pValue is System.Data.DataTable
    				|| pValue is string && (pValue as string).StartsWith("<");
    
    		}
    		if (pType.Equals(typeof(System.Drawing.Bitmap))) {
    			return pValue is System.Drawing.Image || pValue is byte[];
    
    		}
    		if (pType.Equals(typeof(System.Drawing.Image))) {
    			return pValue is System.Drawing.Image || pValue is byte[];
    
    		}
    		if (pType.Equals(typeof(System.Drawing.Color))) {
    			if (pValue is System.Drawing.Color) return true;
    			if (pValue is System.Drawing.KnownColor) {
    				pValue = System.Drawing.Color.FromKnownColor((System.Drawing.KnownColor)pValue);
    				return true;
    			}
    
    			int lARGB;
    			if (!int.TryParse(lsValue = pValue.ToString(), out lARGB)) {
    				if (lsValue.StartsWith("Color [A=", StringComparison.InvariantCulture)) {
    					foreach (string lsARGB in lsValue.Substring("Color [".Length, lsValue.Length - "Color []".Length).Split(','))
    						switch (lsARGB.TrimStart().Substring(0, 1)) {
    							case "A":
    								lARGB = int.Parse(lsARGB.Substring(2)) * 0x1000000;
    								break;
    							case "R":
    								lARGB += int.Parse(lsARGB.TrimStart().Substring(2)) * 0x10000;
    								break;
    							case "G":
    								lARGB += int.Parse(lsARGB.TrimStart().Substring(2)) * 0x100;
    								break;
    							case "B":
    								lARGB += int.Parse(lsARGB.TrimStart().Substring(2));
    								break;
    							default:
    								break;
    						}
    					pValue = System.Drawing.Color.FromArgb(lARGB);
    					return true;
    				}
    				if (lsValue.StartsWith("Color [", StringComparison.InvariantCulture)) {
    					pValue = System.Drawing.Color.FromName(lsValue.Substring("Color [".Length, lsValue.Length - "Color []".Length));
    					return true;
    				}
    				return false;
    			}
    			pValue = System.Drawing.Color.FromArgb(lARGB);
    			return true;
    		}
    		if (pType.IsEnum) {
    			try {
    				if (pValue == null) return false;
    				if (pValue is int || pValue is byte || pValue is ulong || pValue is long || pValue is double)
    					pValue = Enum.ToObject(pType, pValue);
    				else
    					pValue = Enum.Parse(pType, pValue.ToString());
    			}
    			catch {
    				return false;
    			}
    		}
    		return true;
    	}
    }
