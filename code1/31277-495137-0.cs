	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	namespace UnitConversion
	{
	    internal delegate double Converter(double value);
	    class UnitConverter
	    {
	        private readonly IDictionary<string, IDictionary<string, Converter>> converters =
	            new Dictionary<string, IDictionary<string, Converter>>();
	        private readonly NumberFormatInfo numberFormatInfo;
	        public UnitConverter()
	        {
	            numberFormatInfo = (NumberFormatInfo)NumberFormatInfo.InvariantInfo.Clone();
	            numberFormatInfo.NumberDecimalSeparator = ".";
	            numberFormatInfo.NumberGroupSeparator = String.Empty;
	        }
	        public void ParseConverterDefinition(string converterDefinition)
	        {
	            string[] parts = converterDefinition.Split(' ');
	            double sourceUnitsValue = double.Parse(parts[0], NumberFormatInfo.InvariantInfo);
	            double targetUnitsValue = double.Parse(parts[3], NumberFormatInfo.InvariantInfo);
	            AddConverters(parts[1], sourceUnitsValue, parts[4], targetUnitsValue);
	            AddConverters(parts[4], targetUnitsValue, parts[1], sourceUnitsValue);
	        }
	        private void AddConverters(string sourceUnits, double sourceUnitsValue, string targetUnits, double targetUnitsValue)
	        {
	            if (!converters.ContainsKey(sourceUnits))
	                converters.Add(sourceUnits, new Dictionary<string, Converter>());
	            converters[sourceUnits][targetUnits] =
	                delegate(double value)
	                { return value * targetUnitsValue / sourceUnitsValue; };
	        }
	        public double? Convert(double value, string sourceUnits, string targetUnits, params string[] skipUnits)
	        {
	            if (!converters.ContainsKey(sourceUnits))
	                return null;
	            if (converters[sourceUnits].ContainsKey(targetUnits))
	                return converters[sourceUnits][targetUnits](value);
	            foreach (KeyValuePair<string, Converter> pair in converters[sourceUnits])
	            {
	                if (Array.IndexOf(skipUnits, pair.Key) != -1)
	                    continue;
	                List<string> skip = new List<string>(skipUnits);
	                skip.Add(sourceUnits);
	                double? result = Convert(converters[sourceUnits][pair.Key](value), pair.Key, targetUnits, skip.ToArray());
	                if (result != null)
	                    return result;
	            } // foreach
	            return null;
	        }
	        public string Convert(string conversionRequest)
	        {
	            string[] parts = conversionRequest.Split(' ');
	            return ConvertFormatted(double.Parse(parts[0], NumberFormatInfo.InvariantInfo), parts[1], parts[4]);
	        }
	        public string ConvertFormatted(double value, string sourceUnits, string targetUnits)
	        {
	            double? convertedValue = Convert(value, sourceUnits, targetUnits);
	            if (convertedValue == null)
	                return "No conversion is possible.";
	            return string.Format("{0} {1} = {2} {3}", value.ToString("N6", numberFormatInfo), sourceUnits,
	                convertedValue < 0.01 || convertedValue > 1000000 ?
	                    convertedValue.Value.ToString("#.######e+00", numberFormatInfo) :
	                    convertedValue.Value.ToString("N6", numberFormatInfo),
	                targetUnits);
	        }
	    }
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            UnitConverter unitConverter = new UnitConverter();
	            foreach (string s in File.ReadAllLines("Conversions.txt"))
	            {
	                if (s.IndexOf("?") == -1)
	                    unitConverter.ParseConverterDefinition(s);
	                else
	                    Console.WriteLine(unitConverter.Convert(s));
	            } // foreach
	        }
	    }
	}
