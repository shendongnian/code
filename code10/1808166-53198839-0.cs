    void OnTriggerEnter(Collider other){
      if(other.tag == "Player"){
         
              this.GetComponent<AudioSource>().Play();
              Debug.Log("PLayed Sound!");
      }
    }
