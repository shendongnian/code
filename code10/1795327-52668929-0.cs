    public void NuevoLibro(string titolo, string autore, string annoPubb)
    {
        var libro = new Libro(titolo, autore, annoPubb);
        _seed++;
        _libros.Add(seed, libro);
    }
