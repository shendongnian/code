    public class MyAwesomeStream : FileStream
    {
        //...
        public override Dispose(bool disposing)
        {
            //do your event logging / handling here
            base.Dispose(disposing);
        )
    }
