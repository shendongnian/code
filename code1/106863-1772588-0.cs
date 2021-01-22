    public interface IQTimerDatabaseObject
    {
        //whatever implementation you need
    }
    abstract class QTimerDatabaseObject
    {
        public static IQTimerDatabaseObject createFromQTimer(DataRow QTimerRow)
        {
            IQTimerDatabaseObject obj =  //some code to statisfy the interface
            return obj;
        }
        public abstract void saveRow();
    }
    class QTimer : QTimerDatabaseObject
    {
        public new QTimer createFromQTimer(DataRow QTimerRow)
        {
            return QTimerDatabaseObject.createFromQTimer(QTimerRow) as QTimer;
        }
        public override void saveRow()
        {
            throw new NotImplementedException();
        }
    }
      
