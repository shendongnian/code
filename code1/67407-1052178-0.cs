    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        event.Dispose();
      }
      base.Dispose(disposing);
    }
