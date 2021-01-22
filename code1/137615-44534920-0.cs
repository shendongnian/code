	public static class SqlConnectionExtension
	{
		#region Public Methods
		public static bool ExIsOpen(this SqlConnection connection, MessageString errorMsg)
		{
			if (connection == null) return false;
			if (connection.State != ConnectionState.Open)
			{
				try
				{
					connection.Open();
				}
				catch (Exception ex) { errorMsg.Append(ex.ToString()); }
			}
			return true;
		}
		public static bool ExIsReady(this SqlConnection connction, MessageString errorMsg)
		{
			if (ExIsOpen(connction, errorMsg) == false) return false;
			try
			{
				using (SqlCommand command = new SqlCommand("select 1", connction))
				using (SqlDataReader reader = command.ExecuteReader())
					if (reader.Read()) return true;
			}
			catch (Exception ex) { errorMsg.Append(ex.ToString()); }
			return false;
		}
		#endregion Public Methods
	}
	public class MessageString : IDisposable
	{
		#region Protected Fields
		protected StringBuilder _messageBuilder = new StringBuilder();
		#endregion Protected Fields
		#region Public Constructors
		public MessageString()
		{
		}
		public MessageString(int capacity)
		{
			_messageBuilder.Capacity = capacity;
		}
		public MessageString(string value)
		{
			_messageBuilder.Append(value);
		}
		#endregion Public Constructors
		#region Public Properties
		public int Length {
			get { return _messageBuilder.Length; }
			set { _messageBuilder.Length = value; }
		}
		public int MaxCapacity {
			get { return _messageBuilder.MaxCapacity; }
		}
		#endregion Public Properties
		#region Public Methods
		public static implicit operator string(MessageString ms)
		{
			return ms.ToString();
		}
		public static MessageString operator +(MessageString ms1, MessageString ms2)
		{
			MessageString ms = new MessageString(ms1.Length + ms2.Length);
			ms.Append(ms1.ToString());
			ms.Append(ms2.ToString());
			return ms;
		}
		public MessageString Append<T>(T value) where T : IConvertible
		{
			_messageBuilder.Append(value);
			return this;
		}
		public MessageString Append(string value)
		{
			return Append<string>(value);
		}
		public MessageString Append(MessageString ms)
		{
			return Append(ms.ToString());
		}
		public MessageString AppendFormat(string format, params object[] args)
		{
			_messageBuilder.AppendFormat(CultureInfo.InvariantCulture, format, args);
			return this;
		}
		public MessageString AppendLine()
		{
			_messageBuilder.AppendLine();
			return this;
		}
		public MessageString AppendLine(string value)
		{
			_messageBuilder.AppendLine(value);
			return this;
		}
		public MessageString AppendLine(MessageString ms)
		{
			_messageBuilder.AppendLine(ms.ToString());
			return this;
		}
		public MessageString AppendLine<T>(T value) where T : IConvertible
		{
			Append<T>(value);
			AppendLine();
			return this;
		}
		public MessageString Clear()
		{
			_messageBuilder.Clear();
			return this;
		}
		public void Dispose()
		{
			_messageBuilder.Clear();
			_messageBuilder = null;
		}
		public int EnsureCapacity(int capacity)
		{
			return _messageBuilder.EnsureCapacity(capacity);
		}
		public bool Equals(MessageString ms)
		{
			return Equals(ms.ToString());
		}
		public bool Equals(StringBuilder sb)
		{
			return _messageBuilder.Equals(sb);
		}
		public bool Equals(string value)
		{
			return Equals(new StringBuilder(value));
		}
		public MessageString Insert<T>(int index, T value)
		{
			_messageBuilder.Insert(index, value);
			return this;
		}
		public MessageString Remove(int startIndex, int length)
		{
			_messageBuilder.Remove(startIndex, length);
			return this;
		}
		public MessageString Replace(char oldChar, char newChar)
		{
			_messageBuilder.Replace(oldChar, newChar);
			return this;
		}
		public MessageString Replace(string oldValue, string newValue)
		{
			_messageBuilder.Replace(oldValue, newValue);
			return this;
		}
		public MessageString Replace(char oldChar, char newChar, int startIndex, int count)
		{
			_messageBuilder.Replace(oldChar, newChar, startIndex, count);
			return this;
		}
		public MessageString Replace(string oldValue, string newValue, int startIndex, int count)
		{
			_messageBuilder.Replace(oldValue, newValue, startIndex, count);
			return this;
		}
		public override string ToString()
		{
			return _messageBuilder.ToString();
		}
		public string ToString(int startIndex, int length)
		{
			return _messageBuilder.ToString(startIndex, length);
		}
		#endregion Public Methods
	}
