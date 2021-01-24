    public static class ControlExtensions { 
      public static IEnumerable<Control> RecoursiveControls(this Control parent) {
        if (null == parent)
          throw new ArgumentNullException(nameof(parent));
        Queue<Control> agenda = new Queue<Control>(parent.Controls.OfType<Control>());
        while (agenda.Any()) {
          yield return agenda.Peek();
          foreach (var item in agenda.Dequeue().Controls.OfType<Control>())
            agenda.Enqueue(item);
        }
      }
    }
