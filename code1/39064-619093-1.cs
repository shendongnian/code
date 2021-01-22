    class View
    {
      TreeNode Builder(object foo, object bar) { ... }
    }
    
    class Presenter
    {
      void InitView(View v)
      {
        Model.Build(v.Builder);
      }
    }
