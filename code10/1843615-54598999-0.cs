    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "ball")
        {
            Color c = TintColors[Random.Range(0, TintColors.Count)];        
            GetComponent<Renderer>().material.color = c;
    
            // You have already determined what color is selected.
            // all you need do now is assign the string value of that color to the
            // colliding gameObject's tag property.
            col.gameObject.tag = c.ToString();
        }
    }
