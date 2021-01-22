		//--Formats the number after scaling by factors of 1000, and appends a metric unit prefix (e.g. M for *1000000)
		//--Mask, Prov are the standard ToString() parameters (after metric scaling has been performed)
		//--MinPow10 (/Max) should be multipla of 3 and a usually a negative (/Positve) number or zero, if say +9 is used, all is in G or above (/below)
		//--SwitchLimit usualy 1, but could be say 10 or 100 with few/zero decimals, The limit at which to switch prefix, if say 33 then 33000000->33M but 32900000->32900K
		static string FormatMetricPrefix(double Input, String Mask ="F2", IFormatProvider Prov=null, int MinPow10 =-24, int MaxPow10 =24, int SwitchLimit =1) {
			string Prefixes ="yzafpnμm KMGTPEZY";
			int idx=9;
			double tmp=Input;
			if (Input!=0.0) {
				if (+24<MaxPow10)MaxPow10=+24;
				if (MinPow10<-24)MaxPow10=-24;
				idx=(int)Math.Truncate(9.0+Math.Log(Math.Abs(Input/SwitchLimit))/Math.Log(1000.0));
				if (idx<9+(MinPow10/3)) idx=9+(MinPow10/3); // below lower limit
				if (9+(MaxPow10/3)<idx) idx=9+(MaxPow10/3); // Above upper limit
				if (idx<=9)tmp *=Math.Pow(1000.0,9-idx);
                if (9<idx) tmp /=Math.Pow(1000.0,idx-9);
			}
			if (Prov==null)Prov=CultureInfo.InvariantCulture;
			return tmp.ToString(Mask,Prov)+Prefixes.Substring(idx-1,1).Trim();
		}
		static string FormatMetricPrefixF2DK(double Input){return FormatMetricPrefix(Input, Prov:CultureInfo.GetCultureInfo("da-DK"));}
		static string FormatMetricPrefixF2US(double Input){return FormatMetricPrefix(Input, Prov:CultureInfo.GetCultureInfo("en-US"));}
		static string FormatMetricPrefixF0DK(double Input){return FormatMetricPrefix(Input, Mask:"F0", MinPow10:0, Prov:CultureInfo.GetCultureInfo("da-DK"),SwitchLimit:100);}
		static string FormatMetricPrefixF0US(double Input){return FormatMetricPrefix(Input, Mask:"F0", MinPow10:0, Prov:CultureInfo.GetCultureInfo("en-US"),SwitchLimit:100);}
		static void Main(string[] args)
		{
			Console.WriteLine(FormatMetricPrefixF2US(1.234567890E+27));
			Console.WriteLine(FormatMetricPrefixF2US(1234567890));
			Console.WriteLine(FormatMetricPrefixF2US(0.01234567890));
			Console.WriteLine(FormatMetricPrefixF2US(0.00000001234567890));
			Console.WriteLine(FormatMetricPrefixF2US(1.234567890E-26));
			Console.WriteLine(FormatMetricPrefixF0US(0.5));
			Console.WriteLine(FormatMetricPrefixF0US(2));
			Console.WriteLine(FormatMetricPrefixF0US(20000));
			Console.WriteLine(FormatMetricPrefixF0US(87654321));
		}
