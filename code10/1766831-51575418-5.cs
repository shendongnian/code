    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    
    namespace PolyVar
    {
    	class PolyVar : IEnumerator<char>
    	{
    		protected string _value = "";
    		protected string _error = "";
    		protected int _position = 0;
    
    		#region Constructors
    		public PolyVar() { }
    
    		public PolyVar(string value) => this._value = value;
    
    		public PolyVar(XmlDocument data) => this._value = data.OuterXml;
    
    		public PolyVar(XmlElement data) => this._value = data.OuterXml;
    
    		public PolyVar(bool value) => this.AsBool = value;
    
    		public PolyVar(PolyVar data) => this._value = data._value;
    
    		public PolyVar(object data) => this._value = data.ToString();
    		#endregion
    
    		#region Operators
    		public static PolyVar operator +(PolyVar left, string right) => new PolyVar(left._value + right);
    		public static PolyVar operator +(string left, PolyVar right) => new PolyVar(left + right._value);
    
    		public static PolyVar operator +(PolyVar left, PolyVar right) => new PolyVar(left._value + right._value);
    
    		public static bool operator ==(string left, PolyVar right) => (right == left);
    		public static bool operator ==(PolyVar left, string right)
    		{
    			if (left is null) return (right is null) || (right.Length == 0);
    			if (right is null) return false;
    			return right.Equals(left._value, StringComparison.InvariantCultureIgnoreCase);
    		}
    
    		public static bool operator !=(PolyVar left, string right) => !(left == right);
    		public static bool operator !=(string left, PolyVar right) => !(right == left);
    
    		public static bool operator ==(PolyVar left, PolyVar right)
    		{
    			if (left is null) return (right is null) || (right._value.Length == 0);
    			if (right is null) return false;
    			return left == right._value;
    		}
    
    		public static bool operator !=(PolyVar left, PolyVar right) => !(left == right);
    
    		public static bool operator ==(bool left, PolyVar right) => right == left;
    		public static bool operator ==(PolyVar left, bool right)
    		{
    			if (left is null) return false;
    			return left.AsBool == right;
    		}
    
    		public static bool operator !=(PolyVar left, bool right) => !(left == right);
    		public static bool operator !=(bool left, PolyVar right) => !(right == left);
    
    		public static bool operator ==(XmlDocument left, PolyVar right) => (right == left);
    		public static bool operator ==(PolyVar left, XmlDocument right)
    		{
    			if (left is null) return (right is null);
    			if (right is null) return false;
    			return String.Equals(left._value, right.OuterXml, StringComparison.InvariantCultureIgnoreCase);
    		}
    
    		public static bool operator !=(PolyVar left, XmlDocument right) => !(left == right);
    		public static bool operator !=(XmlDocument left, PolyVar right) => !(right == left);
    
    		public static bool operator ==(XmlElement left, PolyVar right) => (right == left);
    		public static bool operator ==(PolyVar left, XmlElement right)
    		{
    			if (left is null) return (right is null);
    			if (right is null) return false;
    			return String.Equals(left._value, right.OuterXml, StringComparison.InvariantCultureIgnoreCase);
    		}
    
    		public static bool operator !=(PolyVar left, XmlElement right) => !(left == right);
    		public static bool operator !=(XmlElement left, PolyVar right) => !(right == left);
    		#endregion
    
    		#region Accessors
    		public string Value { get => this._value; set => this._value = value; }
    
    		public int Length
    		{
    			get => _value.Length;
    			set { if (value < _value.Length) this._value = this._value.Substring(0, value); }
    		}
    
    		public string[] Words => ((this._value.Trim().IndexOf(' ') > 0) ? this._value.Trim().Split(new string[] { " ", "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries) : new string[] { this._value.Trim() });
    
    		protected string FirstWord => this.Words[0];
    
    		public char this[int index]
    		{
    			get
    			{
    				if ((index < 0) || (index >= _value.Length))
    					throw new ArgumentOutOfRangeException();
    
    				return this._value[index];
    			}
    			set
    			{
    				if ((index < 0) || (index >= _value.Length))
    					throw new ArgumentOutOfRangeException();
    
    				string work = this._value.Substring(0, index) + value;
    				if (index < _value.Length - 1)
    					work += this._value.Substring(index + 1);
    
    				this._value = work;
    			}
    		}
    
    		public bool HasError => (this._error.Length > 0);
    		public string Error { get { string e = this._error; this._error = ""; return e; } }
    
    		protected bool AsBool
    		{
    			get
    			{
    				if ((this._value.Length == 0) || (this._value == string.Empty) || (this._value == null)) return false;
    				return (this._value.ToLowerInvariant()[0] == 'y') ||
    					   (this._value.ToLowerInvariant()[0] == 't') ||
    					   ((int)this != 0);
    			}
    
    			set => this._value = (value ? "true" : "false");
    		}
    
    		public XmlDocument AsXmlDocument
    		{
    			set => this._value = value.OuterXml;
    			get
    			{
    				XmlDocument doc = new XmlDocument();
    				this._error = "";
    				try { doc.LoadXml(this._value); }
    				catch (Exception e) { this._error = e.Message; }
    				return doc;
    			}
    		}
    
    		public XmlElement AsXmlElement
    		{
    			set => this._value = value.OuterXml;
    			get
    			{
    				XmlDocument doc = new XmlDocument();
    				this._error = "";
    				XmlElement result = null;
    				try
    				{
    					doc.LoadXml(AsXmlDocument.CreateXmlDeclaration("1.1", "UTF-8", "yes").ToString() + this._value);
    					result = (XmlElement)doc.FirstChild;
    				}
    				catch (Exception e)
    				{
    					this._error = e.Message;
    					result = doc.CreateElement("error");
    					result.InnerText = e.Message;
    				}
    				return result;
    			}
    		}
    
    		protected object Set { set => this._value = value.ToString(); }
    
    		char IEnumerator<char>.Current => this._value[this._position];
    
    		object IEnumerator.Current => this._value[this._position];
    		#endregion
    
    		#region Methods
    		// Generic number conversion function: Attempts to convert the internal _myValue
    		// string into the numeric type specified by the "T" designator:
    		protected T ConvertToNbr<T>()
    		{
    			try { return (T)Convert.ChangeType(this._value, typeof(T)); }
    			catch (Exception e)
    			{
    				this._error = e.Message;
    				return default(T);
    			}
    		}
    
    		public string Substring(int start, int length) =>
    			(start >= 0) ? this._value.Substring(start, length) : this._value.Substring(_value.Length + start, length);
    
    		public string Substring(int start) =>
    			(start >= 0) ? this._value.Substring(start) : this._value.Substring(_value.Length + start);
    
    		public string PadLeft(int toWidth, char with) => this._value.PadLeft(toWidth, with);
    
    		public string PadLeft(int toWidth) => this._value.PadLeft(toWidth);
    
    		public string PadRight(int toWidth, char with) => this._value.PadRight(toWidth, with);
    
    		public string PadRight(int toWidth) => this._value.PadRight(toWidth);
    
    		public char[] ToCharArray() => this._value.ToCharArray();
    
    		public char[] ToCharArray(int startIndex, int Length) => this._value.ToCharArray(startIndex, Length);
    
    		/// <summary>Removes all instances of a specified character from the string.</summary>
    		/// <param name="value">A Char value to remove all instances of from this string.</param>
    		/// <returns>The current string with all of the specified characters removed.</returns>
    		public string Remove(char value) => this._value.Replace(value.ToString(), "");
    
    		/// <summary>Removes all instances of a specified string from the string.</summary>
    		/// <param name="value">A string value to remove all instances of from this string.</param>
    		/// <returns>The current string with all of the specified string removed.</returns>
    		public string Remove(string value) => this._value.Replace(value, "");
    
    		/// <summary>Removes all instances of each element in a specified character array from the string.</summary>
    		/// <param name="value">An array of Char value to remove all instances of from this string.</param>
    		/// <returns>The current string with all of the specified characters removed.</returns>
    		public string Remove(char[] values)
    		{
    			string result = this._value;
    			foreach (char c in values) result = result.Remove(c);
    			return result;
    		}
    
    		/// <summary>Extends the string class to add a UCWords function.</summary>
    		/// <returns>A string with the initial letter of all words in it capitalised with any existing capitalized letters left as found.</returns>
    		public string UCWords()
    		{
    			System.Globalization.TextInfo ti = System.Globalization.CultureInfo.InvariantCulture.TextInfo;
    			return ti.ToTitleCase(this._value.ToLowerInvariant());
    		}
    
    		/// <summary>Extends the string class to add a UCWords function.</summary>
    		/// <param name="strict">If set to true, all letters in the string are converted to lowercase, then the words are capitalised.</param>
    		/// <returns>A string with all individual words in it capitalised.</returns>
    		public string UCWords(bool strict)
    		{
    			if (strict) return this._value.UCWords();
    
    			PolyVar result = new PolyVar(this._value);
    			if (!(result is null) && (result.Length > 0))
    				for (int i = 0; i < result.Length; i++)
    					if (((i == 0) || ("> .\t\r\n".IndexOf(result[i - 1]) > 0)) && (">abcdefghijklmnopqrstuvwxyz".IndexOf(result[i]) > 0))
    						result[i] = char.ToUpperInvariant(result[i]);
    
    			return result;
    		}
    
    		/// <summary>Given a string of valid characters, filters all non-matching characters out of a string.</summary>
    		/// <param name="validChars">A string of valid (permitted) characters to retain.</param>
    		/// <param name="ignoreCase">Specifies whether case should be ignored.</param>
    		/// <returns>A string containing only the permitted characters.</returns>
    		public string Filter(string validChars, bool ignoreCase)
    		{
    			string result = this._value;
    			if ((result.Length == 0) || (validChars.Length == 0)) return "";
    			if (ignoreCase)
    			{
    				validChars = validChars.ToLowerInvariant();
    				foreach (char c in validChars)
    					if (" abcdefghijklmnopqrstuvwxyz".IndexOf(c) > 0) validChars += (char)(c & 223);
    			}
    
    			int i = 0;
    			while (i < result.Length)
    				if (validChars.IndexOf(result.Substring(i, 1)) < 0)
    					result = result.Remove(result.Substring(i, 1));
    				else i++;
    
    			return result;
    		}
    
    		/// <summary>Given a string of valid characters, filters all non-matching (case-insensitive) characters out of a string.</summary>
    		/// <param name="validChars">A string of valid (permitted) characters to retain.</param>
    		/// <returns>A string containing only the permitted characters.</returns>
    		public string Filter(string validChars) => this.Filter(validChars, true);
    
    		/// <summary>Given an array valid characters, filters all non-matching (case-insensitive) characters out of a string.</summary>
    		/// <param name="validChars">An array of valid (permitted) characters to retain.</param>
    		/// <returns>A string containing only the permitted characters.</returns>
    		public string Filter(char[] validChars) => this.Filter(new string(validChars), true);
    
    		/// <summary>Given an array valid characters, filters all non-matching characters out of a string.</summary>
    		/// <param name="validChars">An array of valid (permitted) characters to retain.</param>
    		/// <param name="ignoreCase">Specifies whether case should be ignored.</param>
    		/// <returns>A string containing only the permitted characters.</returns>
    		public string Filter(char[] validChars, bool ignoreCase) => this.Filter(new string(validChars), ignoreCase);
    
    
    		public static implicit operator string(PolyVar data) => data.Value;
    		public static implicit operator PolyVar(string data) => new PolyVar(data);
    
    		public static implicit operator int(PolyVar data) => data.ConvertToNbr<int>();
    		public static implicit operator PolVar(int data) => new PolyVar(data);
    
    		public static implicit operator sbyte(PolyVar data) => data.ConvertToNbr<sbyte>();
    		public static implicit operator PolyVar(sbyte data) => new PolyVar(data);
    
    		public static implicit operator short(PolyVar data) => data.ConvertToNbr<short>();
    		public static implicit operator PolyVar(short data) => new PolyVar(data);
    
    		public static implicit operator long(PolyVar data) => data.ConvertToNbr<long>();
    		public static implicit operator PolyVar(long data) => new PolyVar(data);
    
    		public static implicit operator decimal(PolyVar data) => data.ConvertToNbr<decimal>();
    		public static implicit operator PolyVar(decimal data) => new PolyVar(data);
    
    		public static implicit operator float(PolyVar data) => data.ConvertToNbr<float>();
    		public static implicit operator PolyVar(float data) => new PolyVar(data);
    
    		public static implicit operator double(PolyVar data) => data.ConvertToNbr<double>();
    		public static implicit operator PolyVar(double data) => new PolyVar(data);
    
    		public static implicit operator uint(PolyVar data) => data.ConvertToNbr<uint>();
    		public static implicit operator PolyVar(uint data) => new PolyVar(data);
    
    		public static implicit operator byte(PolyVar data) => data.ConvertToNbr<byte>();
    		public static implicit operator PolyVar(byte data) => new PolyVar(data);
    
    		public static implicit operator ulong(PolyVar data) => data.ConvertToNbr<ulong>();
    		public static implicit operator PolyVar(ulong data) => new PolyVar(data);
    
    		public static implicit operator ushort(PolyVar data) => data.ConvertToNbr<ushort>();
    		public static implicit operator PolyVar(ushort data) => new PolyVar(data);
    
    		public static implicit operator bool(PolyVar data) => data.AsBool;
    		public static implicit operator PolyVar(bool data) => new PolyVar(data);
    
		    public static implicit operator XmlDocument(PolyVar data) => data.AsXmlDocument;
		    public static implicit operator PolyVar(XmlDocument data) => new PolyVar(data);
		    public static implicit operator XmlElement(PolyVar data) => data.AsXmlElement;
		    public static implicit operator PolyVar(XmlElement data) => new PolyVar(data);
    
    		public override string ToString() => this._value;
    
    		public override bool Equals(object obj) => this._value.Equals(obj);
    
    		public override int GetHashCode() => this._value.GetHashCode();
    
    		public IEnumerator<char> GetEnumerator() => this._value.GetEnumerator();
    
    		bool IEnumerator.MoveNext() => (++this._position) < this._value.Length;
    
    		void IEnumerator.Reset() => this._position = 0;
    
    		#region IDisposable Support
    		private bool disposedValue = false; // To detect redundant calls
    
    		protected virtual void Dispose(bool disposing)
    		{
    			if (!disposedValue)
    			{
    				if (disposing)
    				{
    					// TODO: dispose managed state (managed objects).
    				}
    
    				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
    				// TODO: set large fields to null.
    
    				disposedValue = true;
    			}
    		}
    
    		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    		// ~AppletParameters() {
    		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    		//   Dispose(false);
    		// }
    
    		// This code added to correctly implement the disposable pattern.
    		void IDisposable.Dispose()
    		{
    			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    			Dispose(true);
    			// TODO: uncomment the following line if the finalizer is overridden above.
    			// GC.SuppressFinalize(this);
    		}
    		#endregion
    		#endregion
    	}
    }
