    builder.Property(fornecedor => fornecedor.Nome)
    .IsRequired()
    .HasColumnType("varchar")
    .IsUnicode(false)
    .HasMaxLength(Fornecedor.TamanhoNome);
