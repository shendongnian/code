    void Main()
    {
       //Instantiate cameras
       //Subscribe to the ImageGrabbed events of each (producers)
       
       // A simple blocking consumer with no cancellation.
       Task.Run(() => DetectFace());
    }
    producer1(sender, e)
    {
       //Get snapshot
    ...
       if (!tupleCollection.Any(x => x.Item1 == 1))
       {
          tupleCollection.Add(new Tuple<int, Image>(1, snapshot));
       }
       else
          imageBox1.Image = snapshot;
    }
    
    producer2(sender, e)
    {
       //Get snapshot
    ...
       if (!tupleCollection.Any(x => x.Item1 == 2))
       {
          tupleCollection.Add(new Tuple<int, Image>(2, snapshot));
       }
       else
          imageBox2.Image = snapshot;
    }
    ...
    producerX(sender, e)
    {
       //Get snapshot
    ...
       if (!tupleCollection.Any(x => x.Item1 == X))
       {
          tupleCollection.Add(new Tuple<int, Image>(X, snapshot));
       }
       else
          imageBoxX.Image = snapshot;
    }
    
    private void DetectFace()
    {
       while (true)
       {
          Tuple<int, Image> data = null;
          try
          {
              data = tupleCollection.Take();
          }
          catch (InvalidOperationException) { }
    
          if (data != null)
          {
             //image processing
          }
       }
    }
