      //Create the vertex buffer
      VertexBuffer = new Buffer(device, RawVertexInfo, new BufferDescription {
        SizeInBytes = RawVertexInfo.Length * sizeof(Vertex),
        Usage = ResourceUsage.Default,
        BindFlags = BindFlags.VertexBuffer,
        CpuAccessFlags = CpuAccessFlags.None,
        OptionFlags = ResourceOptionFlags.None,
        StructureByteStride = sizeof(Vertex)
      });
      //Create the index buffer
      IndexCount = (int)RawIndexInfo.Length;
      IndexBuffer = new Buffer(device, RawIndexInfo, new BufferDescription {
        SizeInBytes = IndexCount * sizeof(ushort),
        Usage = ResourceUsage.Default,
        BindFlags = BindFlags.IndexBuffer,
        CpuAccessFlags = CpuAccessFlags.None,
        OptionFlags = ResourceOptionFlags.None,
        StructureByteStride = sizeof(ushort)
      });
      //Create the Depth/Stencil view.
      Texture2D DepthStencilTexture = new Texture2D(device, new Texture2DDescription {
        Format = Format.D32_Float,
        BindFlags = BindFlags.DepthStencil,
        Usage = ResourceUsage.Default,
        Height = renderForm.Height,
        Width = renderForm.Width,
        ArraySize = 1,
        MipLevels = 1,
        SampleDescription = new SampleDescription {
          Count = 1,
          Quality = 0,
        },
        CpuAccessFlags = 0,
        OptionFlags = 0
      });
      DepthStencilBuffer = new DepthStencilView(device, DepthStencilTexture);
      SimpleDepthStencilState = new DepthStencilState(device, new DepthStencilStateDescription {
        IsDepthEnabled = true,
        DepthComparison = Comparison.Less,
      });
      //default blend state - can be omitted from the application if defaulted.
      SimpleBlendState = new BlendState(device, new BlendStateDescription {
    
      });
      //Default rasterizer state - can be omitted from the application if defaulted.
      SimpleRasterState = new RasterizerState(device, new RasterizerStateDescription {
        CullMode = CullMode.Back,
        IsFrontCounterClockwise = false,
      });
      // Input layout.
      VertexBufferLayout = new InputLayout(device, VertexShaderByteCode, new InputElement[] {
        new InputElement {
          SemanticName = "POSITION",
          Slot = 0,
          SemanticIndex = 0,
          Format = Format.R32G32B32_Float,
          Classification = InputClassification.PerVertexData,
          AlignedByteOffset = 0,
          InstanceDataStepRate = 0,
        },
        new InputElement {
          SemanticName = "NORMAL",
          Slot = 0,
          SemanticIndex = 0,
          Format = Format.R32G32B32_Float,
          Classification = InputClassification.PerVertexData,
          AlignedByteOffset = InputElement.AppendAligned,
          InstanceDataStepRate = 0,
        },
        new InputElement {
          SemanticName = "TEXCOORD0",
          Slot = 0,
          SemanticIndex = 0,
          Format = Format.R32G32_Float,
          Classification = InputClassification.PerVertexData,
          AlignedByteOffset = InputElement.AppendAligned,
          InstanceDataStepRate = 0,
        },
      });
      //Vertex/Pixel shaders
      SimpleVertexShader = new VertexShader(device, VertexShaderByteCode);
      SimplePixelShader = new PixelShader(device, PixelShaderByteCode);
      //Constant buffers
      TransformationMatrixBuffer = new Buffer(device, new BufferDescription {
        SizeInBytes = sizeof(TransformationMatrixParameters),
        BindFlags = BindFlags.ConstantBuffer,
        Usage = ResourceUsage.Default,
        CpuAccessFlags = CpuAccessFlags.None,
      });
      AmbientLightBuffer = new Buffer(device, new BufferDescription {
        SizeInBytes = sizeof(AmbientLightParameters),
        BindFlags = BindFlags.ConstantBuffer,
        Usage = ResourceUsage.Default,
        CpuAccessFlags = CpuAccessFlags.None,
      });
      // Mesh texture
      MeshTexture = new Texture2D(device, new Texture2DDescription {
        Format = Format.B8G8R8A8_UNorm,
        BindFlags = BindFlags.ShaderResource,
        Usage = ResourceUsage.Default,
        Height = MeshImage.Height,
        Width = MeshImage.Width,
        ArraySize = 1,
        MipLevels = 0,
        CpuAccessFlags = CpuAccessFlags.None,
        OptionFlags = ResourceOptionFlags.None,
        SampleDescription = new SampleDescription {
          Count = 1, 
          Quality = 0,
        }
      });
      //Shader view for the texture
      MeshTextureView = new ShaderResourceView(device, MeshTexture);
      //Sampler for the texture
      MeshTextureSampler = new SamplerState(device, new SamplerStateDescription {
        AddressU = TextureAddressMode.Clamp,
        AddressV = TextureAddressMode.Clamp,
        AddressW = TextureAddressMode.Border,
        BorderColor = new SharpDX.Mathematics.Interop.RawColor4(255, 0, 255, 255),
        Filter = Filter.MaximumMinMagMipLinear,
        ComparisonFunction = Comparison.Never,
        MaximumLod = float.MaxValue,
        MinimumLod = float.MinValue,
        MaximumAnisotropy = 1,
        MipLodBias = 0,
      });
