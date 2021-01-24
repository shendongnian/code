    bool canMove = true;
    for each (GameObject clone in GameObject.FindGameObjectsWithTag()){
        if (clone.GetComponent<script>().move_states == 1)
            canMove = false;
    }
    if(canMove == true)
        Movement_input(); 
