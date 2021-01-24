bool isVis=false;
  
    void OnGUI(){
     if (isVis)
            {
        GUI.Box(new Rect(Input.mousePosition.x + 2, Screen.height - Input.mousePosition.y + 2, 128, 72), "Tool Tip Text");
                   } 
        }
 
    private void OnMouseEnter()
        {
            isVis = true;
           
        }
        private void OnMouseExit()
        {
            isVis = false;
           
        }
