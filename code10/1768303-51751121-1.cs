      private Chart CreateSomeChart(SomeViewModel vm, int width, int height)
      {
          int Id = vm.Id;
          System.Web.UI.DataVisualization.Charting.Chart Chart1 = new System.Web.UI.DataVisualization.Charting.Chart();
          // usual code to draw a chart here...
          return Chart1;
      }
