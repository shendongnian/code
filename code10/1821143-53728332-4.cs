    private bool collisonOccured = false;
    private void OnCollisionEnter(Collision collision){
        if(collisonOccured)
            return;
        if(collision.gameObject.CompareTag("Wall")){
            if(WallFloatingText){
                ShowWallFloatingText();
                count = count + 3;
                countText.text = count.ToString();
                collisonOccured = true;
            }
        }
    }
