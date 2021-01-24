    IEnumerable<Project> Consolidate(IEnumerable<Project> data) {
        // I need to create a new list of these objects with all the objects 
        //consolidated when the BeginDate of one object matches the EndDate 
        //of the previous one within 24 hours, going back until there is a break longer than 24 hours.
        using (var e = data.GetEnumerator()) {
            if (e.MoveNext()) {
                var previous = e.Current;
                while (e.MoveNext()) {
                    var next = e.Current;
                    if (previous.BeginDate.AddDays(-1) > next.EndDate) {
                        yield return previous;
                        previous = next;
                        continue;
                    }
                    previous = new Project {
                        BeginDate = next.BeginDate,
                        EndDate = previous.EndDate ?? DateTime.Now
                    };
                }
                yield return previous;
            }
        }
    }
