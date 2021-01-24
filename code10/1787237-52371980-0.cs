    private GameObject nearTo = null
    
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Mar Room") {
            nearTo = other.gameObject;
        }
    }
    
    private void Update() {
        if(nearTo != null && Input.GetKeyDown(name: "e")) {
            //do stuff
            nearTo = null; //set to null when we're done
        }
    }
