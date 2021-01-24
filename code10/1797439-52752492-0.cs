    class ToStore {
     //Constructor here, or add public sets
     public YourClass Data {get;}
     public DateTime AddedAtUtc {get;} 
     //I would suggest using NodaTime's Instant, but that's out of scope for this question.
    }
    public void Add(YourClass data )
    {
        if (data == null)
        {
           throw new ArgumentNullException(nameof(data ));
        }
        var frame = new ToStore {
            Data = data,
            AddedUtc = DateTime.UtcNow 
        }
        dict.TryAdd(frame.TimestampUtc, frame);
        OnAdd(); // fire and forget
    }
