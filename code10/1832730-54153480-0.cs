    void SpriteUpdate()
    {
        if (spriteNumber > ObjectSprite.Length)
        {
            this.GetComponent<SpriteRenderer>().sprite = ObjectSprite[spriteNumber];
            Instantiate(coin, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
