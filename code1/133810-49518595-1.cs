    public class MyEntity {
		int Id;
		public MyEntity(int id){
			Id = id;
		}
		public override bool Equals(object obj) => Equals(obj as MyEntity);
		public bool Equals(MyEntity obj) => obj != null && Id == obj.Id;
		public override int GetHashCode() => Id;
	}
