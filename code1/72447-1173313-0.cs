    [ActiveRecord("PostTable")]
    public class Post : ActiveRecordBase<Post>
    {
         private int _id;
         private DateTime _created;
         [PrimaryKey]
         public int Id
         {
            get { return _id; }
            set { _id = value; }
         }
         [Property("created")]
         public DateTime Created
         {
            get { return _created; }
            set { _created = value; }
         }
         private void BeforeUpdate()
         {
            // code that run before update
            Created = DateTime.Now;
         }
        public override void Update()
        {
            BeforeUpdate();
            base.Update();            
        }
