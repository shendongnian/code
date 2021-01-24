    private void OnEnable(){
           MazeGenerator.OnMazeReady += StartDirectives;   
    }
    private void OnDisable(){
           MazeGenerator.OnMazeReady -= StartDirectives;   
    }
