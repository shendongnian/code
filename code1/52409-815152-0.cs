      var x = 976129709;
      var target = new DateTime(2009, 1, 14, 17, 53, 26);
      var testTicks = target.AddTicks(-x);     // 2009-01-14 17:51:48
      var testMs = target.AddMilliseconds(-x); // 2009-01-03 10:44:36
      var testS = target.AddSeconds(-x);       // 1978-02-08 22:44:57
      // No need to check for bigger time units
      // since your input indicates second precision.
