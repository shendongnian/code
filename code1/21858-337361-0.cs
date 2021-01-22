          DateTime a = DateTime.Now;
          DateTime b = a.AddDays(2);
          // ticks are in hns
          long ticks = b.Ticks - a.Ticks;
          long seconds = ticks / 10000000;
          long minutes = seconds / 60;
          long hours = minutes / 60;
          long days = hours / 24;
