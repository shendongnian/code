      while (continueTrying) {
        retval = sqlite_exec(db, sqlQuery, callback, 0, &msg);
        switch (retval) {
          case SQLITE_BUSY:
            Log("[%s] SQLITE_BUSY: sleeping fow a while...", threadName);
            sleep a bit... (use something like sleep(), for example)
            break;
          case SQLITE_OK:
            continueTrying = NO; // We're done
            break;
          default:
            Log("[%s] Can't execute \"%s\": %s\n", threadName, sqlQuery, msg);
            continueTrying = NO;
            break;
        }
      }
    
      return retval;
