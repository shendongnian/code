	public class Vector
	{
		private object[] _Data;
		public object this[int index]
		{
			get
			{
				return _Data[index];
			}
		}
		public Vector(params object[] data)
		{
			_Data = (object[])data.Clone();
		}
		public override bool Equals(object obj)
		{
			Vector OtherVector = obj as Vector;
			if (OtherVector == null)
				return false;
			if (OtherVector._Data.Length != _Data.Length)
				return false;
			for (int I = 0; I < _Data.Length; I++)
				if (!_Data[I].Equals(OtherVector._Data[I]))
					return false;
			return true;
		}
		public override int GetHashCode()
		{
			int Result = 0;
			for (int I = 0; I < _Data.Length; I++)
				Result = Result ^ (_Data[I].GetHashCode() * I);
			return Result;
		}
	}
