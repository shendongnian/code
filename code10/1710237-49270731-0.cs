    var consultaGerente = _contexto.PDFGenerados
        .Where(x => x.nGerente == Gerente)
        .Select(i => i.vRutaArchivo.Replace("/", "\\"))
        .Distinct()
        .ToList();
    using (ZipFile fileZip = new ZipFile())
    {
        foreach (var i in consultaGerente)
        {
            var fileRoute = carpetaCorrecta + i;
            zip.AddFile(fileRoute, "PDF");
        }
    }
