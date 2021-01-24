    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class ImageScript : MonoBehaviour {
    private bool selected;
    Vector3 currentPosition;
    ImageScript secondImage;
    void Update()
    {
        if (selected == true)
        {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPos.x, cursorPos.y, -1.0f);
        
        } 
    //Mouse is released
        if(Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(transform.position, secondImage.transform.position) < 1f)
            {
                //Distance to second image is less than 1 on mouse up which makes the both images disappear.
                
                ScoreScript.scoreValue += 1/6f;
                selected = false;
                Destroy(SecondImage);
                Destroy(this);
            }
            else
            {
                //Distance to second image on mouse up is higher than 1 which resets the position back to original.
                transform.position = currentPosition;
            }
            //Ignore these:
            // Vector3 position = transform.position;
            // position[2] = 0;
            // transform.position = position;
            //This is where I think I should check for overlap
    }
    }
    void OnMouseOver() {
    if(Input.GetMouseButtonDown(0)) 
    {
        selected = true;
        currentPosition = transform.position;
        }
    }
