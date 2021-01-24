    /// <summary>
    /// Writes the given text to the response body using the given encoding.
    /// </summary>
    /// <param name="response">The <see cref="HttpResponse"/>.</param>
    /// <param name="text">The text to write to the response.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <param name="cancellationToken">Notifies when request operations should be cancelled.</param>
    /// <returns>A task that represents the completion of the write operation.</returns>
    public static Task WriteAsync(this HttpResponse response, string text, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (response == null)
        {
            throw new ArgumentNullException(nameof(response));
        }
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }
        if (encoding == null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }
        byte[] data = encoding.GetBytes(text);
        return response.Body.WriteAsync(data, 0, data.Length, cancellationToken);
    }
