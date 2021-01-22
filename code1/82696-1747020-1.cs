      //Get the initial position and dragged points using LINQ to Events
                var mouseDragPoints = from md in e.GetMouseDown()
                                      let startpos=md.EventArgs.GetPosition(e)
                                      from mm in e.GetMouseMove().Until(e.GetMouseUp())
                                      select new
                                      {
                                          StartPos = startpos,
                                          CurrentPos = mm.EventArgs.GetPosition(e),
                                      };
     //And subscribe here to mouseDragPoints
