    public class LoggerSqlClientDriver:SqlClientDriver, IEmbeddedBatcherFactoryProvider
    {      
        public override void AdjustCommand(IDbCommand command)
        {
            //log here
            base.AdjustCommand(command);
        }
        //protected override void OnBeforePrepare(IDbCommand command)
        //{
        //    //log here
        //    base.OnBeforePrepare(command);
        //}
    }
