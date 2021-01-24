    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Player") {
                canvasTesoroFoto.SetActive (true);
                canvasTesoroDatos.SetActive (true);
            }
    }
