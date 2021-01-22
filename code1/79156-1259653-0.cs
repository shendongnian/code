	public class Employee
	{
		private int? m_ID;
		
		public int? ID
		{
			get { return m_ID; }
			set
			{
				if (m_ID.HasValue())
					throw ...
				m_ID = value;
			}
		}
	}
