    public class MyRepo<TEntity>
    {
        public void GetData(Expression<Func<TEntity, bool>> expression, out List<TEntity> result)
        {
            result = null;
        }
    
        public List<TEntity> GetData(Func<TEntity, bool> whereClause)
        {
            return null;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var myRepo = new MyRepo<MyEntity>();
        var i = myRepo.GetData(x => x.Id == 1);
        myRepo.GetData(x => x.Id == 1, out i);
    }
