      ...
      public DraggableControl()
      {
        ...
        MouseMove += OnMouseMove;
      }
      ...
      private void OnMouseMove(object sender, MouseEventArgs e)
      {
        // Calculate distance between inital and updated mouse position
        var movedDistance = (_initialMousePosition - e.GetPosition(this)).Length;
        if (movedDistance > yourThreshold)
        {
          DragDrop.DoDragDrop(...);
        }
      }
    }
