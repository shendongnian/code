    List<YourObject> m_list; //The list of objects drawn in the panel.
    
    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        foreach(YourObject obj in list)
        {
            if(obj.IsHit(e.X, e.Y))
            {
                //Do Something
            }
        }
    }
