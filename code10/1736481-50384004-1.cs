        static IMemoryOwner<byte> GetNodeSpan(in ReadOnlyMemory<byte> payload)
        {
            ReadOnlySpan<byte> payloadHeader = BitConverter.GetBytes(payload.Length);
            var result = MemoryPool<byte>.Shared.Rent(
                                        RESP_BULK_ID.Length +
                                        payloadHeader.Length +
                                        RESP_FOOTER.Length +
                                        payload.Length +
                                        RESP_FOOTER.Length);
            Span<byte> cursor = result.Memory.Span;
            // ...
            return result;
        }
