    try { // Some code }
    catch (System.IO.DirectoryNotFoundException) { }
    catch (System.IO.DriveNotFoundException) { }
    catch (System.IO.EndOfStreamException) { }
    catch (System.IO.FileLoadException) { }
    catch (System.IO.FileNotFoundException) { }
    catch (System.IO.InternalBufferOverflowException) { }
    catch (System.IO.InvalidDataException) { }
    catch (System.IO.PathTooLongException) { }
    catch (System.IO.IOException) { // Something else happened. Check InnerException details }
